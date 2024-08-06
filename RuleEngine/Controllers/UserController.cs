using FluentValidation;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Mvc;
using RuleEngine.Model;
using RuleEngine.Validator;

namespace RuleEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("getDiscount")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public IActionResult GetUserDiscount()
        {
            try
            {
                UserDiscount userDiscount = new UserDiscount { UserLevel="Gold",PurchaseAmount =120};
                UserDiscountValidator userValidator = new ();
                var validatorResult = userValidator.Validate( new ValidationContext <UserDiscount>(userDiscount,null,new RulesetValidatorSelector(new[] { "CalculateDiscount" })));
                if (validatorResult.IsValid)
                {
                    return Ok(new { Messagr = userDiscount.DiscountMessage ?? "Discount Calculation Successfull" });
                }
                else
                {
                    return Ok("Validation Error");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
