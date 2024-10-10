using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Aplication.DTOs
{
	public class QueryParameter
	{
		private int _pageNumber = 1;
		private int _pageSize = 5;
		private const int RECORDS_PER_PAGE = 5;

		public int PageNumber
		{
			get => _pageNumber;
			set => _pageNumber = value <= 0 ? _pageNumber = 1 : _pageNumber = value;
		}
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = value < RECORDS_PER_PAGE ? _pageSize = RECORDS_PER_PAGE : _pageSize = value;
		}
	}
}
