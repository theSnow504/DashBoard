using System.ComponentModel;

namespace Dashboard.Common.Enums
{
	public enum GroupType
	{
		[Description("Chưa tham gia nhóm")]
		NotJoin = 1,
		[Description("Đã tham gia nhóm")]
		Joined = 2
	}
}
