using JobBoard.Domain.Entities;
using JobBoard.Domain.Enums;

namespace JobBoard.Application.Helpers;

public static class AccountUtil
{
    public static AccountRole GetRole(this Account account)
    {
        return account switch
        {
            User => AccountRole.User,
            Company => AccountRole.Company,
            Admin => AccountRole.Admin,
            _ => throw new ArgumentException("Unknown account type")
        };
    }
}