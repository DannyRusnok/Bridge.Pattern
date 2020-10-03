namespace Bridge.Pattern.BridgePatternApproach
{
    public abstract class Authority
    {
        public string Name { get; }

        protected Authority(string name)
        {
            Name = name;
        }

        public abstract string GetAuthorityVerb();
    }

    public class ApprovingAuthority : Authority
    {
        public ApprovingAuthority(string name) : base(name) { }

        public override string GetAuthorityVerb() => "approved";
    }

    public class BanningAuthority : Authority
    {
        public BanningAuthority(string name) : base(name) { }

        public override string GetAuthorityVerb() => "banned";
    }
}