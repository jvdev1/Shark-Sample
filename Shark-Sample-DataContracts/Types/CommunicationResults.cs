namespace SharkSample.DataContracts
{
    public enum CommunicationResults : byte
    {
        /// <summary>
        /// Describes unsupported result
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that requestor does not have permission for requested request
        /// </summary>
        NotPermitted,

        /// <summary>
        /// Indicates that requestor does not have valid credential for requested request
        /// </summary>
        InvalidCredential,

        /// <summary>
        /// Indicates that requested request is not valid
        /// </summary>
        InvalidRequest,

        /// <summary>
        /// Indicates that requested request was performed successfully
        /// </summary>
        OK
    }
}
