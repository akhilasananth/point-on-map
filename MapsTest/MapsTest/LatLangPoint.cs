using System;

public class LatLangPoint
{
    private double lat;
    private double lng;

	public LatLangPoint(double lat, double lng)
	{
        this.lat = lat;
        this.lng = lng;
	}

    public double getLat()
    {
        return this.lat;
    }

    public double getLng()
    {
        return this.lng;
    }
}
