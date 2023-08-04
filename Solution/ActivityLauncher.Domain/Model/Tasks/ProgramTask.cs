﻿using System.Text;
using ActivityLauncher.Domain.Common.Utils;
using ActivityLauncher.Domain.Enums;
using ActivityLauncher.Domain.Interfaces;

namespace ActivityLauncher.Domain.Model.Tasks;

public class ProgramTask : BaseTask, ICloneable<ProgramTask>
{
    public override TaskType TaskType => TaskType.ProgramTask;

    public string ProgramName { get; set; } = string.Empty;

    public string ProgramFilePath { get; set; } = string.Empty;

    public string ArgumentList { get; set; } = string.Empty;

    private bool HasProgramName => !string.IsNullOrWhiteSpace(ProgramName);

    public override bool IsValid()
    {
        return HasProgramName || ValidationHelper.IsValidFile(ProgramFilePath);
    }

    protected override string GetValidScript()
    {
        if (HasProgramName)
        {
            return $"Start-Process {ProgramName}";
        }

        var builder = new StringBuilder();

        builder.Append($"Start-Process -FilePath \"{ProgramFilePath}\"");

        if (!string.IsNullOrWhiteSpace(ArgumentList))
        {
            builder.Append($" -ArgumentList \"{ArgumentList}\"");
        }

        return builder.ToString();
    }

    public ProgramTask Clone()
    {
        return new ProgramTask()
        {
            Id = Id,
            Name = Name,
            CreationDate = CreationDate,
            ProgramName = ProgramName,
            ProgramFilePath = ProgramFilePath,
            ArgumentList = ArgumentList,
        };
    }
}
