﻿using System.Text.RegularExpressions;
using Framework;
using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class NationalId : ValueObject
{
    public string Value { get; private set; }
    private NationalId(string value)
    {
        Value = value;
    }

    public static Result<NationalId> Create(string nationalCode)
    {
        //در صورتی که کد ملی وارد شده تهی باشد

        if (string.IsNullOrEmpty(nationalCode))
            return Result.Failure<NationalId>("لطفا کد ملی را صحیح وارد نمایید");


        //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
        if (nationalCode.Length != 10)
            return Result.Failure<NationalId>("طول کد ملی باید ده کاراکتر باشد");

        //در صورتی که کد ملی ده رقم عددی نباشد
        var regex = new Regex(@"\d{10}");
        if (!regex.IsMatch(nationalCode))
            return Result.Failure<NationalId>("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

        //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
        var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
        if (allDigitEqual.Contains(nationalCode))
            return Result.Failure<NationalId>("کد ملی صحیح نمی باشد");


        //عملیات شرح داده شده در بالا
        var chArray = nationalCode.ToCharArray();
        var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
        var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
        var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
        var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
        var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
        var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
        var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
        var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
        var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
        var a = Convert.ToInt32(chArray[9].ToString());

        var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
        var c = b % 11;

        return c < 2 && a == c || c >= 2 && 11 - c == a
            ? new NationalId(nationalCode)
            : Result.Failure<NationalId>("کد ملی صحیح نمی باشد");
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}