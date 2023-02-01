namespace ProductsCategoriesAPI.IModels
{
    public interface IApiResponse<T>
    {
        /// <summary>
        /// Result data
        /// </summary>
        T Data { get; set; }

        /// <summary>
        /// HTTP status code
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// A message that specifies the nature of occurred error in the case when Success is <see langword="false"/>
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Indicate that request has been handled successfully 
        /// </summary>
        bool Success => Data != null;
    }
}
