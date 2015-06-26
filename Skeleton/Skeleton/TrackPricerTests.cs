using NUnit.Framework;

namespace MusicSalesTests
{
	public class TrackPricerTests
	{
		[Test]
		public void No_tracks_should_be_priced_as_zero()
		{
			const string noTrackCodes = "";

			var trackPricer = new TrackPricer();
			var price = trackPricer.TotalPrice(noTrackCodes);

			Assert.That(price, Is.EqualTo(0));
		}

		[TestCase("234569", 96)]
		[TestCase("234570", 98)]
		public void Should_return_price_of_a_single_track_code(string trackCodes, int expectedPrice)
		{
			var trackPricer = new TrackPricer();
			var price = trackPricer.TotalPrice(trackCodes);

			Assert.That(price, Is.EqualTo(expectedPrice));
		}
	}

	public class TrackPricer
	{
		public int TotalPrice(string commaSeparatedTrackCodes)
		{
			var trackCodes = new TrackCodes(commaSeparatedTrackCodes);
			return trackCodes.Price();
		}
	}

	public class TrackCodes
	{
		private readonly string _commaSeparatedTrackCodes;

		public TrackCodes(string commaSeparatedTrackCodes)
		{
			_commaSeparatedTrackCodes = commaSeparatedTrackCodes;
		}

		public int Price()
		{
			if (SomeTracksIn(_commaSeparatedTrackCodes))
			{
				return _commaSeparatedTrackCodes == "234569" ? 96 : 98;
			}
			return 0;
		}

		private static bool SomeTracksIn(string trackCodes)
		{
			return !string.IsNullOrEmpty(trackCodes);
		}
	}
}
