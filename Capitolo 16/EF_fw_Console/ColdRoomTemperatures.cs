//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_fw_Console
{
    using System;
    using System.Collections.Generic;
    
    public partial class ColdRoomTemperatures
    {
        public long ColdRoomTemperatureID { get; set; }
        public int ColdRoomSensorNumber { get; set; }
        public System.DateTime RecordedWhen { get; set; }
        public decimal Temperature { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    }
}