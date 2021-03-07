public interface ITargetSettings : ISettings
{
    BaseSkinDatabase<BallSkin> SkinsDatabase { get; }
    float MinSpeed { get; }
    float MaxSpeed { get; }
    float MinSize { get; }
    float MaxSize { get; }
}