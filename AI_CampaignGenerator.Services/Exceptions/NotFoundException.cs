using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Exceptions
{

    public abstract class NotFoundException(string message) : Exception(message)
    {

    }

    public sealed class UserNotFoundException(string id) : NotFoundException($"User with id {id} was not found.");
    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product with id {id} was not found.");
    public sealed class CampaignNotFoundException(int id) : NotFoundException($"Campaign with id {id} was not found.");
    public sealed class AIGeneratedContentNotFoundException(int id) : NotFoundException($"AI Generated Content with id {id} was not found.");
    public sealed class ProductImageNotFoundException(int id) : NotFoundException($"Product Image with id {id} was not found.");
    public sealed class AIGeneratedContentImageNotFoundException(int id) : NotFoundException($"AI Generated Content Image with id {id} was not found.");
}
