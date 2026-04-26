// Copyright: 2026 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.SourceGenerators.Attributes;

/// <summary>
/// Indicates that the decorated <c>class</c> should have a factory pattern generated for it.
/// The source generator discovers all concrete implementations of the specified interface at
/// compile time and emits a <c>Create(string key)</c> method that maps keys to concrete types.
/// </summary>
/// <param name="interfaceType">The interface type whose implementations should be discovered.</param>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class GenerateFactoryAttribute(Type interfaceType) : Attribute
{
	/// <summary>
	/// Gets the interface type whose implementations are discovered at compile time.
	/// </summary>
	public Type InterfaceType => interfaceType;
}
