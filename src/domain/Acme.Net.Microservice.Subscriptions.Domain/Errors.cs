namespace Acme.Net.Microservice.Subscriptions.Domain;

public class Errors: IErrorCodes
{    
    public const string UnknownError = "100 : UnknownError";
    public const string InvalidId = "101 : The Id Subscription is invalid";
    public const string InvalidIdClient = "102 : The Id Client is invalid";
    public const string InvalidIdProduct = "103 : The Id Product is invalid";
    public const string InvalidTenant = "104 : The Tenant is invalid";
    public const string InvalidCreatedBy = "105 : The CreatedBy is invalid";
    public const string InvalidStartDate  = "106 : The StartDate is invalid";
    public const string InvalidEndDate = "107 : The EndDate is invalid";
    public const string StartDateGreaterThanEndDate = "108 : The StartDate is greater than EndDate";
    public const string InvalidUpdatedBy = "109 : The UpdatedBy is invalid";
}
