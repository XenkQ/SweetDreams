using UnityEngine;

public static class DialogHexColors
{
    public static string PlayerColor = "#FFFFFF";
    public static string EntityColor = "#C82020";

    public static string GetHexColorRelatedToDialogWriters(DialogWriters dialogWriters)
        => dialogWriters switch { 
            DialogWriters.Player => PlayerColor,
            DialogWriters.Entity => EntityColor,
            _ => ""
        };
}