using Xunit;
using Moq;
using RenergyInsights.DAL.Interfaces;
using RenergyInsights.Business.IServices;
using RenergyInsights.DTO;
using RenergyInsights.Business.Services;


namespace RenergyInsights.TEST

{
    public class ReEnergyExamine
    {
        private readonly Mock<IConsumerEnergyRepository> _mockRepo;
        private readonly IConsumerInsights _consumerService;

        public ReEnergyExamine()
        {
            _mockRepo = new Mock<IConsumerEnergyRepository>();
            _consumerService = new ConsumerInsights(_mockRepo.Object);
        }

        [Fact]
        public void GetConsumerDetails_ReturnsSuccess_WhenBothDataSourcesExist()
        {
            // setup
            var testDirectData = new List<ConsumerDetailDto>
        {
            new ConsumerDetailDto { Year = 2023, DirectValue = 1.2, RenewableWasteEnergy = 5.1 },
            new ConsumerDetailDto { Year = 2022, DirectValue = 1.3, RenewableWasteEnergy = 5.2 }
        };

            var testReallocatedData = new List<ConsumerDetailDto>
        {
            new ConsumerDetailDto { Year = 2023, ReallocatedValue = 1.6 },
            new ConsumerDetailDto { Year = 2022, ReallocatedValue = 1.7}
        };

            _mockRepo.Setup(x => x.GetDirectConsumerDetails(It.IsAny<string>()))
                    .Returns(testDirectData);
            _mockRepo.Setup(x => x.GetReallocatedConsumerDetails(It.IsAny<string>()))
                    .Returns(testReallocatedData);

            // test
            var result = _consumerService.GetConsumerDetails("anyhtingIsgood");

            // Assert
            Assert.True(result.Status);
            //Assert.Equal("Data retrieved successfully", result.Message);    // need to check
            Assert.Equal(2, result.Data.Count());

            // Veriy of join
            var firstItem = result.Data.First();
            Assert.Equal(2023, firstItem.Year);
            Assert.Equal(1.2, firstItem.DirectValue);
            Assert.Equal(1.6, firstItem.ReallocatedValue);
            Assert.Equal(5.1, firstItem.RenewableWasteEnergy);

            Assert.Empty(result.Error);
        }
    }
}
