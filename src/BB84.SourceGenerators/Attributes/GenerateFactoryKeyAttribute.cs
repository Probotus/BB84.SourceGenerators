// Copyright: 2026 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.SourceGenerators.Attributes;

/// <summary>
/// Specifies a custom key for a class when used with the <see cref="GenerateFactoryAttribute"/> generator.
/// When this attribute is not present, the class name is used as the factory key.
/// </summary>
/// <param name="key">The custom key to use for this implementation in the generated factory.</param>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class GenerateFactoryKeyAttribute(string key) : Attribute
{
	/// <summary>
	/// Gets the custom key for this implementation.
	/// </summary>
	public string Key => key;
}
