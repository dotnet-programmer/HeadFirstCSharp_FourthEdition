namespace PaintballGun.ConsoleApp;

internal class PaintballGunClass
{
	//public const int MAGAZINE_SIZE = 16;
	public int MagazineSize { get; private set; } = 16;

	private int balls = 0;

	//private int ballsLoaded = 0;
	//public int GetBallsLoaded() => ballsLoaded;

	public bool IsEmpty() => BallsLoaded == 0;

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
		get => balls;
		set
		{
			if (value > 0)
			{
				balls = value;
			}
			Reload();
		}
	}

	public PaintballGunClass(int balls, int magazineSize, bool loaded)
	{
		this.balls = balls;
		MagazineSize = magazineSize;
		if (!loaded)
		{
			Reload();
		}
	}

	//public void Reload() => BallsLoaded = balls > MAGAZINE_SIZE ? MAGAZINE_SIZE : balls;
	public void Reload() => BallsLoaded = balls > MagazineSize ? MagazineSize : balls;

	public bool Shoot()
	{
		if (BallsLoaded == 0)
		{
			return false;
		}

		BallsLoaded--;
		balls--;
		return true;
	}
}