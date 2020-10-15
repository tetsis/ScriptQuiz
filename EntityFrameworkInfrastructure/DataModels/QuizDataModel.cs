using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkInfrastructure.DataModels
{
    [Table("Quizzes")]
    public class QuizDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Choice1 { get; set; }

        [Required]
        public string Choice2 { get; set; }

        [Required]
        public string Choice3 { get; set; }

        [Required]
        public string Choice4 { get; set; }

        [Required]
        public int AnswerNumber { get; set; }
    }
}

/*
CREATE TABLE [dbo].[Quizzes]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Question] NVARCHAR(100) NOT NULL, 
    [Choice1] NVARCHAR(50) NOT NULL, 
    [Choice2] NVARCHAR(50) NOT NULL, 
    [Choice3] NVARCHAR(50) NOT NULL, 
    [Choice4] NVARCHAR(50) NOT NULL, 
    [AnswerNumber] INT NOT NULL
)
 */
