# System.Text.Json Converter

This nuget package allows you to make System.Text.Json behave like Newtonsoft.Json.

It should run smoothly with System.Text.Json version 4.6.0 and greater.
To Install : 

```
Install-Package Straightforward.Converters
```

The package solve mainly the quoted numbers and nullable quoted numbers issue with System.Text.Json.

I wrote this package upgrading a project I worked on since Asp.Net Core 1.0. It should behave exactly the same as Newtonsoft.Json. Should any problem occur, I will be happy to help.

You can use the Serializer class for manual operations. And you can configure the framewrok to use the converters in Startup.cs like this :

```
services
    .AddControllersWithViews()
//  .AddControllers() also works
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        o.JsonSerializerOptions.AllowTrailingCommas = true;
        o.JsonSerializerOptions.Converters.Add(new QuotedIntConverter());
        o.JsonSerializerOptions.Converters.Add(new QuotedDoubleConverter());
        o.JsonSerializerOptions.Converters.Add(new QuotedFloatConverter());
        o.JsonSerializerOptions.Converters.Add(new QuotedLongConverter());

        o.JsonSerializerOptions.Converters.Add(new QuotedIntConverterNullable());
        o.JsonSerializerOptions.Converters.Add(new QuotedDoubleConverterNullable());
        o.JsonSerializerOptions.Converters.Add(new QuotedFloatConverterNullable());
        o.JsonSerializerOptions.Converters.Add(new QuotedLongConverterNullable());
    });
```

I suggest not including the IsoDateTimeConverter if it's not needed. 

===================

Copyright (c) <2020> <copyright Msaddaa Alaeddine>


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
