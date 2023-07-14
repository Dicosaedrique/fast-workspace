﻿namespace FastWorkspace.Domain.Jobs;

public class ScriptJob : BaseJob
{
    public string Script { get; set; } = string.Empty;

    public override string GetScript()
    {
        return Script;
    }

    public override string GetDefaultName() => "Execute Custom PowerShell Script";
}
