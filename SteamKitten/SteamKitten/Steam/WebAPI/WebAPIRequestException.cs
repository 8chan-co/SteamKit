﻿using System;
using System.Net.Http;

namespace SteamKitten
{
    /// <summary>
    /// Thrown when WebAPI request fails.
    /// </summary>
    public sealed class WebAPIRequestException : SteamKittenWebRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebAPIRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="response">HTTP response message including the status code and data.</param>
        public WebAPIRequestException(string message, HttpResponseMessage response)
            : base(message, response)
        {
        }

        /// <inheritdoc/>
        public WebAPIRequestException()
        {
        }

        /// <inheritdoc/>
        public WebAPIRequestException( string message ) : base( message )
        {
        }

        /// <inheritdoc/>
        public WebAPIRequestException( string message, System.Exception innerException ) : base( message, innerException )
        {
        }
    }
}
