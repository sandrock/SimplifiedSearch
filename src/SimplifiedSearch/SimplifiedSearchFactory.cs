﻿using SimplifiedSearch.SearchPipelines;
using SimplifiedSearch.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedSearch
{
    internal class SimplifiedSearchFactory
    {
        private readonly ISimplifiedSearch _simplifiedSearch;

        private ISimplifiedSearch BuildSimplifiedSearch()
        {
            var lowercaseFilter = new LowercaseFilter();
            var asciiFoldingFilter = new AsciiFoldingFilter();
            var tokenizeFilter = new TokenizeFilter();
            var pipeline = new SearchPipeline(lowercaseFilter, asciiFoldingFilter, tokenizeFilter);
            var propertyBuilder = new PropertyBuilder();
            return new SimplifiedSearchImpl(pipeline, propertyBuilder);
        }

        public SimplifiedSearchFactory()
        {
            _simplifiedSearch = BuildSimplifiedSearch();
        }

        public ISimplifiedSearch GetSimplifiedSearch()
        {
            return _simplifiedSearch;
        }
    }
}
