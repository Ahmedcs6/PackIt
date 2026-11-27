using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Shared.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (PackItException e)
		{
			context.Response.StatusCode = 400;
			context.Response.Headers.Add("content-type", "application/json");
			var errorCode = e.GetType().Name.Replace("Exception", string.Empty).ToSnakeCase();
			var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, e.Message });
			await context.Response.WriteAsync(json);
		}
	}
}

public static partial class StringExtensions
{
	[GeneratedRegex("([a-z0-9])([A-Z])")]
	private static partial Regex PascalCaseRegex();

	public static string ToSnakeCase(this string input) =>
		PascalCaseRegex().Replace(input, "$1_$2").ToLowerInvariant();
}
