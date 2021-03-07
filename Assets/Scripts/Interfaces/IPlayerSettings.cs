public interface IPlayerSettings : ISettings
{
    BaseSkinDatabase<PlayerSkin> SkinDatabase { get; }
    int Speed { get; }
}