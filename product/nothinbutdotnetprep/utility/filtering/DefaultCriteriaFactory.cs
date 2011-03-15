﻿using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter,ReturnType> propertyAccessor)
        {
            this.property_accessor = propertyAccessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return AbstractConditionalCriteriaFactory<ItemToFilter>.
                ConditionalCriteria<ItemToFilter>(item => property_accessor(item).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return AbstractConditionalCriteriaFactory<ItemToFilter>.
                ConditionalCriteria<ItemToFilter>(item =>
                                                             new List<ReturnType>(values).Contains(
                                                                 property_accessor(item)));
        }

        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }
    }
}