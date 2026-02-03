namespace SofaBioscoop.Domain
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium;
        private MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            this.movieScreening = movieScreening;
            this.isPremium = isPremiumReservation;
            this.rowNr = seatRow;
            this.seatNr = seatNr;
        }

        public bool IsPremiumTicket() => isPremium;

        public double GetPrice() => movieScreening.GetPricePerSeat();

        public override string ToString()
        {
            return $"Row: {rowNr}, Seat: {seatNr} ({(isPremium ? "Premium" : "Standard")})";
        }

        public MovieScreening GetMovieScreening() => movieScreening;
    }
}