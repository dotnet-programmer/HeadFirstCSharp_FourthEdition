namespace PaintballGun.ConsoleApp;

internal class PaintballGunClass
{
	private int _balls = 0;

	public PaintballGunClass(int balls, int magazineSize, bool loaded)
	{
		_balls = balls;
		MagazineSize = magazineSize;
		if (!loaded)
		{
			Reload();
		}
	}

	//public const int MAGAZINE_SIZE = 16;
	public int MagazineSize { get; private set; } = 16;

	//private int ballsLoaded = 0;
	//public int GetBallsLoaded() => ballsLoaded;
	public int BallsLoaded { get; private set; }

	//public int GetBalls() => balls;

	//public void SetBalls(int numberOfBalls)
	//{
	//	if (numberOfBalls > 0)
	//	{
	//		balls = numberOfBalls;
	//	}
	//	Reload();
	//}

	public int Balls
	{
		get => _balls;
		set
		{
			if (value > 0)
			{
				_balls = value;
			}
			Reload();
		}
	}

	public bool IsEmpty()
		=> BallsLoaded == 0;

	public void Reload()
		=> BallsLoaded = _balls > MagazineSize ? MagazineSize : _balls;

	public bool Shoot()
	{
		if (BallsLoaded == 0)
		{
			return false;
		}

		BallsLoaded--;
		_balls--;
		return true;
	}
}