﻿using System.Collections.Immutable;
using System.Linq;

namespace Fujiberg.Coder.CSharp;

public sealed record Attribution(QualifiedName Name)
{
    public IImmutableList<Expression> OrderedArguments { get; init; } = [];

    public static Attribution Create(QualifiedName name, params Expression[] orderedArguments)
    {
        return new Attribution(name) with {OrderedArguments = [..orderedArguments]};
    }

    public string ToCode()
    {
        var cw = new CodeWriter();
        cw.Write("[");
        cw.Write(Name.ToCode());
        if (OrderedArguments.Any())
        {
            cw.Write("(");
            cw.Write(string.Join(", ", OrderedArguments.Select(x => x.ToCode())));
            cw.Write(")");
        }

        cw.Write("]");
        return cw.ToString();
    }
}
