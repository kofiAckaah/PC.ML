using Microsoft.ML.Data;

using PC.ML.Core.Exceptions;
using PC.ML.Core.RequestDtos;

using PC_ML_Core;

namespace PC.ML.Core.Services
{
    public class PriceCheckerService : IPriceCheckerService
    {
        public async Task<decimal> CheckPrice(PriceCheckerRequestDto request)
        {
            try
            {
                //Load sample data
                var sampleData = new PCModel.ModelInput()
                {
                    CPU = request.CPU,
                    GHz = request.GHz,
                    GPU = request.GPU,
                    RAM = request.RAM,
                    RAMType = request.RAMType,
                    Screen = request.Screen,
                    Storage = request.Storage,
                    SSD = request.SSD,
                    Weight = request.Weight,
                };

                //Load model and predict output
                var result = PCModel.Predict(sampleData);

                return await Task.FromResult((decimal)Math.Round(result.Score, 2, MidpointRounding.AwayFromZero));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new MLException(ex.Message);
            }
        }
    }

    public interface IPriceCheckerService
    {
        Task<decimal> CheckPrice(PriceCheckerRequestDto request);
    }
}
