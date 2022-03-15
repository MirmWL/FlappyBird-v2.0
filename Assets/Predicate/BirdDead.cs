using Birds;

public class BirdDead : IPredicate
{
    private readonly Bird _bird;

    public BirdDead(Bird bird)
    {
        _bird = bird;
    }
    public bool Execute()
    {
        return _bird.IsDead();
    }
}
