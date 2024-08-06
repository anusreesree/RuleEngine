using FluentValidation;
using RuleEngine.Model;

namespace RuleEngine.Validator
{
    public class UserDiscountValidator : AbstractValidator<UserDiscount>
    {
        public UserDiscountValidator()
        {
            RuleFor(user => user.UserLevel).NotEmpty();
            RuleFor(user => user.PurchaseAmount).GreaterThan(0);

            RuleSet("CalculateDiscount",() =>{
            RuleFor(discount =>discount.PurchaseAmount)
                .Custom((amount,context)=>
                {
                    var userLevel = context.InstanceToValidate.UserLevel;
                    if (userLevel == "Gold" && amount >=100)
                    {
                        context.InstanceToValidate.DiscountMessage = "Gold get a 20% discount on purchase";
                    }
                    else if (userLevel == "Silver" && amount >= 100)
                    {
                        context.InstanceToValidate.DiscountMessage = "Silver get a 10% discount on purchase";
                    }
                });

            });
        }
    }
}
