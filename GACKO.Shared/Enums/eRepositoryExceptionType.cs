namespace GACKO.Shared.Enums
{
    /// <summary>
    /// Repository Actions handled by RepositoryException
    /// </summary>
    public enum eRepositoryExceptionType
    {
        /// <summary>
        /// Exception occured during creation of an database entity
        /// </summary>
        Create,
        /// <summary>
        /// Exception occured during updating of an database entity
        /// </summary>
        Update,
        /// <summary>
        /// Exception occured during retrieving of an database entity
        /// </summary>
        Get,
        /// <summary>
        /// Exception occured during deleting of an database entity
        /// </summary>
        Delete
    }
}
