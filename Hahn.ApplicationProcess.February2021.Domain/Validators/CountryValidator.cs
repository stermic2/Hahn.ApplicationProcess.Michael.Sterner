using System;
using FluentValidation;
using RestSharp;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    public static class CountryValidator
    {
        private static readonly RestClient RestClient = new RestClient();
        public static IRuleBuilderOptions<T, TProperty> Country<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder) {
            return ruleBuilder.Must(x => !RestClient.GetAsync<string>(
                    new RestRequest(new Uri($"https://restcountries.eu/rest/v2/name/{x}?fullText=true"))).Result.Contains("404"))
                .WithMessage("Country Invalid/Not Found at restcountries.eu");
        }
    }
}