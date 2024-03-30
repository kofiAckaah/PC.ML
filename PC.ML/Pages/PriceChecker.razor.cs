using Microsoft.AspNetCore.Components;

using MudBlazor;

using PC.ML.Core.Exceptions;
using PC.ML.Core.RequestDtos;
using PC.ML.Core.Services;

namespace PC.ML.Pages
{
    public partial class PriceChecker
    {
        [Inject]
        public IPriceCheckerService? PriceCheckerService { get; set; }
        [Inject]
        public ISnackbar? Snackbar { get; set; }
        private PriceCheckerRequestDto requestDto = new();
        private decimal price = 0;

        protected async Task CheckPrice()
        {
            try
            {
                price = await PriceCheckerService.CheckPrice(requestDto);
                Snackbar.Add("Success.", Severity.Success);
            }
            catch (MLException ex)
            {
                Snackbar.Add("Error retrieving Price. Try again.", Severity.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Reset()
        {
            requestDto = new PriceCheckerRequestDto();
            price = 0;
            Snackbar.Add("Form reset.", Severity.Info);
        }
    }
}
