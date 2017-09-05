public class Company {
	private double previousCompanyValue;
	private double currentCompanyValue;
	private double stockPrice;
	private double dividendPerShare;

	private float chanceOfTrend;
	private float rateForIncrease;
	private float rateForNeutral;
	private float rateForDecrease;
	private float rateOfChange;

	private int totalNumberOfShares;

	public Company(double startingValue, float chanceOfTrend, float rateForIncrease,
					float rateForDecrease, float rateOfChange, int totalNumberOfShares) {
		previousCompanyValue = currentCompanyValue = startingValue;
		dividendPerShare = 0;
		stockPrice = startingValue / totalNumberOfShares;
		this.chanceOfTrend = chanceOfTrend;
		this.rateForIncrease = rateForIncrease;
		this.rateForDecrease = rateForDecrease;
		this.rateForNeutral = 1 - rateForIncrease - rateForDecrease;
		this.totalNumberOfShares = totalNumberOfShares;
	}

	public double newCompanyValue(double currentValue, double previousValue) {
		double incDecRate;
		double changeRate;

		if (currentValue > previousValue) {
			incDecRate = rateForIncrease + Math.min(rateForIncrease, 1 - rateForIncrease) * chanceOfTrend;
		} else if (previousValue > currentValue) {
			incDecRate = rateForIncrease - Math.min(rateForIncrease, 1 - rateForIncrease) * chanceOfTrend;
		} else {
			incDecRate = rateForIncrease;
		}

		Random r = new Random();

		double randNum = r.nextDouble();
		changeRate = r.nextDouble() * rateOfChange;

		if (randNum > (1 - incDecRate)) return (currentValue * (1 + changeRate));
		else if (randNum > (1 - incDecRate - rateForNeutral)) return currentValue;
		else return (currentValue * (1 - changeRate));
	}

	public double getDividedPerShare() {
		dividendPerShare = (currentCompanyValue - previousCompanyValue) / totalNumberOfShares;	//Can add to this by accounting for expenses
																								//Rather than taking the increase in revenue as pure profit.
		return dividendPerShare;
	}

	public double getStockPrice() {
		stockPrice = currentCompanyValue / totalNumberOfShares;
		return stockPrice;
	}

	public float getRateForIncrease() {
		return rateForIncrease;
	}
	
	public float getRateForDecrease() {
		return rateForDecrease;
	}
	
	public float getRateForNeutral() {
		return rateForNeutral;
	}

	public float getRateOfChance() {
		return rateOfChange;
	}

	public float getChanceOfTrend() {
		return chanceOfTrend;
	}

	public int getTotalNumberOfShares() {
		return totalNumberOfShares;
	}

	// Change these company parameters perhaps when they release a successful/unsuccessful product
	// Or a rivalling company does the same, or when a new rival company sets up and gains a large following etc.
	public void setRateForIncrease(float rateForIncrease) {
		this.rateForIncrease = rateForIncrease;
		rateForNeutral = 1 - rateForIncrease - rateForDecrease;
	}

	public void setRateForDecrease(float rateForDecrease) {
		this.rateForDecrease = rateForDecrease;
		rateForNeutral = 1 - rateForIncrease - rateForDecrease;
	}

	public void setRateOfChange(float rateOfChange) {
		this.rateOfChange = rateOfChange;
	}

	public void setChanceOfTrend(float chanceOfTrend) {
		this.chanceOfTrend = chanceOfTrend;
	}

	public void setTotalNumberOfShares(int totalNumberOfShares) {
		this.totalNumberOfShares = totalNumberOfShares;
	}
}