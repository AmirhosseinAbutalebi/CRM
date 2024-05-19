namespace Crm.Domain.Shared
{
    /// <summary>
    /// this class just marker for BaseValueObject
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
