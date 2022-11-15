using AutoMapper;
using SFM.Automation.QuickbooksImport.Data.Models.Fleetio;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Data.AutoMapper.Profiles
{
    /// <summary>
    ///   An AutoMapper profile for <see cref="WorkOrder"/> objects.
    /// </summary>
    public class WorkOrderProfile : Profile
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkOrderProfile"/> class.
        /// </summary>
        public WorkOrderProfile()
        {
            CreateMap<WorkOrder, FleetioWorkOrder>()
                .ForMember(d => d.CompletedAt, s => s.MapFrom(i => i.CompletedAt))
                .ForMember(d => d.CreatedAt, s => s.MapFrom(i => i.CreatedAt))
                .ForMember(d => d.Description, s => s.MapFrom(i => i.Description))
                .ForMember(d => d.Discount, s => s.MapFrom(i => i.Discount))
                .ForMember(d => d.DiscountPercentage, s => s.MapFrom(i => i.DiscountPercentage))
                .ForMember(d => d.DiscountType, s => s.MapFrom(i => i.DiscountType))
                .ForMember(d => d.Id, s => s.MapFrom(i => i.Id))
                .ForMember(d => d.Number, s => s.MapFrom(i => i.Number))
                .ForMember(d => d.Tax1, s => s.MapFrom(i => i.Tax1))
                .ForMember(d => d.Tax1Percentage, s => s.MapFrom(i => i.Tax1Percentage))
                .ForMember(d => d.Tax1Type, s => s.MapFrom(i => i.Tax1Type))
                .ForMember(d => d.Tax2, s => s.MapFrom(i => i.Tax2))
                .ForMember(d => d.Tax2Percentage, s => s.MapFrom(i => i.Tax2Percentage))
                .ForMember(d => d.Tax2Type, s => s.MapFrom(i => i.Tax2Type))
                .ForMember(d => d.UpdatedAt, s => s.MapFrom(i => i.UpdatedAt))
                .ForMember(d => d.VehicleId, s => s.MapFrom(i => i.VehicleId))
                .ForMember(d => d.VehicleName, s => s.MapFrom(i => i.VehicleName))
                .ForMember(d => d.VendorId, s => s.MapFrom(i => i.VendorId))
                .ForMember(d => d.VendorName, s => s.MapFrom(i => i.VendorName))
                .ForMember(d => d.WorkOrderId, s => s.MapFrom(i => i.Id))
                .ForMember(d => d.WorkOrderStatusName, s => s.MapFrom(i => i.WorkOrderStatusName))
                .ForMember(d => d.IssuedAt, s => s.MapFrom(i => i.IssuedAt))
                .ForMember(d => d.TotalAmount, s => s.MapFrom(i => i.Total_Amount))
                .ForMember(d => d.Accounting_date, s => s.MapFrom(i => i.CustomFields.Accounting_date))
                .ReverseMap()
                ;
        }
    }
}