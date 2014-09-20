using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpGhost.Models;

namespace SharpGhost
{
    /// <summary>
    /// Internal HttpClient helper class
    /// </summary>
    internal class GhostHttpClient
    {
        /// <summary>
        /// Make a POST request
        /// </summary>
        /// <typeparam name="T">Expected return type.</typeparam>
        /// <param name="requestUri">Http client request URI.</param>
        /// <param name="content">POST request content.</param>
        /// <returns></returns>
        internal async Task<T> PostAsync<T>(string requestUri, FormUrlEncodedContent content) where T: class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                T ghostResponse = null;
                HttpResponseMessage response = await httpClient.PostAsync(requestUri, content).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    string errorStringResponse = await response.Content.ReadAsStringAsync();
                    string errorsString = JObject.Parse(errorStringResponse).SelectToken("errors").ToString();

                    await Task.Factory.StartNew(() =>
                        {
                            IList<GhostError> errors = JsonConvert.DeserializeObject<IList<GhostError>>(errorsString);

                            GhostException exception;

                            if (errors.Any())
                            {
                                exception = new GhostException
                                {
                                    GhostErrorMessage = errors[0].ErrorMessage,
                                    GhostErrorType = errors[0].ErrorType
                                };
                            }
                            else
                            {
                                exception = new GhostException(errorStringResponse);
                            }

                            throw exception;
                        }
                    );
                }
                else
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();

                    await Task.Factory.StartNew(() =>
                        {
                            ghostResponse = JsonConvert.DeserializeObject<T>(stringResponse);
                        }
                    );
                }

                return ghostResponse;
            }
        }
    }
}
