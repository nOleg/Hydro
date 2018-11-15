using System;
namespace Gold.Vikings.Models{
    public interface IClient{
        int ClientId{get;set;} 
        string ClientName{ get; set; }
        string ClientPhone{ get; set; }
        DateTime ClientRegistred{ get; set; }
    }
}