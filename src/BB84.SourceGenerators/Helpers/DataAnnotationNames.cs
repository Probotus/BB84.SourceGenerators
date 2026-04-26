// Copyright: 2026 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.SourceGenerators.Helpers;

/// <summary>
/// Contains fully qualified names of data annotation attributes used by the <see cref="ValidatorGenerator"/>.
/// </summary>
internal static class DataAnnotationNames
{
	internal const string Required = "System.ComponentModel.DataAnnotations.RequiredAttribute";
	internal const string Range = "System.ComponentModel.DataAnnotations.RangeAttribute";
	internal const string StringLength = "System.ComponentModel.DataAnnotations.StringLengthAttribute";
	internal const string MinLength = "System.ComponentModel.DataAnnotations.MinLengthAttribute";
	internal const string MaxLength = "System.ComponentModel.DataAnnotations.MaxLengthAttribute";
	internal const string RegularExpression = "System.ComponentModel.DataAnnotations.RegularExpressionAttribute";
}
