// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
#if NETSTANDARD2_0

namespace AsmArm64;

/// <summary>
/// Applied to a method that will never return under any circumstance.
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
[Microsoft.CodeAnalysis.Embedded]
internal sealed class DoesNotReturnAttribute : Attribute
{
}
#endif
