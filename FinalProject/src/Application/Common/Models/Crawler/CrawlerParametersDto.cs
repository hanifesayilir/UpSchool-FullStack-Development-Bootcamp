﻿using Domain.Enums;

namespace Application.Common.Models.Crawler
{
    public class CrawlerParametersDto
    {
        public bool RequestedAll { get; set; }
        public int  RequestedQuantity { get; set; }
        public ProductCrawlType ProductCrawlType { get; set; }

       /* public CrawlerParametersDto(bool requestedAll, int requestedQuantity, ProductCrawlType productCrawlType)
        {
            RequestedAll = requestedAll;
            RequestedQuantity = requestedQuantity;
            this.productCrawlType = productCrawlType;
        }*/
    }
}
