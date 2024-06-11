﻿using System.ComponentModel;

namespace Dashboard.Common.Enums
{
	public enum StatusLogin
	{
        [Description("Fail")]
        Fail = 99,
        [Description("Success")]
		Success = 1,
		[Description("No license")]
		NoLicense = 2,
		[Description("License expired")]
		LicenseExpires = 3,
        [Description("User not existing")]
        UserNotExisting = 4,
        [Description("Password wrong")]
        PasswordWrong = 5,
        [Description("Token expired")]
        TokenExpired = 6
    }
}
