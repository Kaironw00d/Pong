public interface ITarget
{
    GameObjectPool Pool { get; set; }
    ITargetSettings Settings { get; }
    void ApplySettings();
}