//=================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using Xunit;

namespace Sheenam.Api.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            //given => kerakli ma'lumotlarni olib kelish
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest storageGuest = inputGuest;
            Guest expectedGuest = storageGuest.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGuestAsync(inputGuest))
                .ReturnsAsync(storageGuest);

            //when=> kerakli methodlarni chaqirish
            Guest actualGuest = 
                await this.guestService.AddGuestAsync(inputGuest);

            //then => tasdiqlash
            actualGuest.Should().BeEquivalentTo(randomGuest);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertGuestAsync(inputGuest),
               Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
