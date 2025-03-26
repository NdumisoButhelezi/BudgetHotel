using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetHotel.Models
{
    public class GuestBooking
    {
        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public int NumberOfNights { get; set; }

        [Required]
        public decimal PricePerPersonPerNight { get; set; }

        private const decimal VAT_RATE = 0.15m; // 15% VAT

        // Calculate total before VAT
        public decimal CalculateTotalBeforeVAT()
        {
            decimal total = NumberOfGuests * NumberOfNights * PricePerPersonPerNight;

            // Apply discount if booking is more than 3 nights
            if (NumberOfNights > 3)
            {
                decimal discount = NumberOfGuests * (PricePerPersonPerNight / 2); // Half price for one night per guest
                total -= discount;
            }

            return total;
        }

        // Calculate VAT amount
        public decimal CalculateVAT()
        {
            return CalculateTotalBeforeVAT() * VAT_RATE;
        }

        // Calculate total after VAT
        public decimal CalculateTotalAfterVAT()
        {
            return CalculateTotalBeforeVAT() + CalculateVAT();
        }
    }
}
