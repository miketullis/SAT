using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Added for access to DataAnnotations

namespace SAT.DATA.EF//.Metadata
{
    #region Student Metadata
    public class StudentMetadata
    {
        //public int StudentID { get; set; }

        [Required(ErrorMessage = "* First Name is required *")]
        [StringLength(20, ErrorMessage = "* Cannot exceed 20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name is required *")]
        [StringLength(20, ErrorMessage = "* Cannot exceed 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(15, ErrorMessage = "* Cannot exceed 15 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Major { get; set; }

        [StringLength(50, ErrorMessage = "* Cannot exceed 50 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "* Cannot exceed 50 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "* Value must be 2 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string State { get; set; }

        [StringLength(10, ErrorMessage = "* Cannot exceed 10 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "* Value must be a valid number, 0 or larger")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", NullDisplayText = "[-N/A-]")]
        public string Phone { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        
        [StringLength(100, ErrorMessage = "* Cannot exceed 100 characters")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [Display(Name = "Photo URL")]
        public string PhotoURL { get; set; }

        //public int SSID { get; set; }
    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string FullAddress
        {
            get { return Address + ", " + City + ", " + State + ", " + ZipCode; }
        }
    }
    #endregion

    #region Enrollment Metadata
    public class EnrollmentMetadata
    {
        //public int EnrollmentId { get; set; }

        //public int StudentId { get; set; }

        //public int ScheduledClassId { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }
    #endregion

    #region Scheduled Classes Metadata
    public class ScheduledClassesMetadata
    {
        //public int EnrollmentId { get; set; }

        //public int StudentId { get; set; }

        //public int ScheduledClassId { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(ScheduledClassesMetadata))]
    public partial class ScheduledClasses
    {

    }
    #endregion

    #region Student Statuses Metadata
    public class StudentStatusesMetadata
    {
        //public int SSID { get; set; }

        [Required(ErrorMessage = "* Status Name is required *")]
        [StringLength(30, ErrorMessage = "* Cannot exceed 30 characters")]
        [Display(Name = "Name")]
        public string SSName { get; set; }

        [StringLength(250, ErrorMessage = "* Cannot exceed 250 characters")]
        [Display(Name = "Description")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string SSDescription{ get; set; }
    }

    [MetadataType(typeof(StudentStatusesMetadata))]
    public partial class StudentStatuses
    {

    }
    #endregion

    #region Scheduled Class Statuses Metadata
    public class ScheduledClassStatusesMetadata
    {
        //public int SCSID { get; set; }

        [Required(ErrorMessage = "* Class Status Name is required *")]
        [StringLength(30, ErrorMessage = "* Cannot exceed 30 characters")]
        [Display(Name = "Name")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusesMetadata))]
    public partial class ScheduledClassStatuses
    {

    }
    #endregion
    
    #region Courses Statuses Metadata
    public class CoursesMetadata
    {
        //public int CourseId { get; set; }

        [Required(ErrorMessage = "* Course Name is required *")]
        [StringLength(50, ErrorMessage = "* Cannot exceed 50 characters")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "* Course Description is required *")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "* Credit Hours are required *")]
        [Range(0, double.MaxValue, ErrorMessage = "* Value must be a valid number, 0 or larger")]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }

        [StringLength(250, ErrorMessage = "* Cannot exceed 250 characters")]
        public string Cirriculum { get; set; }

        [StringLength(500, ErrorMessage = "* Cannot exceed 500 characters")]
        public string Notes { get; set; }

        [Display(Name = "Active Course")]
        public bool IsActive { get; set; }

    }

    [MetadataType(typeof(CoursesMetadata))]
    public partial class Courses
    {

    }
    #endregion

}



