namespace Cataloguer.UI
{
    partial class MovieDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.panelPoster = new System.Windows.Forms.Panel();
            this.labelGenreDescription = new System.Windows.Forms.Label();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.labelReleaseDateDescription = new System.Windows.Forms.Label();
            this.labelRuntime = new System.Windows.Forms.Label();
            this.labelRuntimeDescription = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelCompanyDescription = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.labelFormatDescription = new System.Windows.Forms.Label();
            this.labelQuality = new System.Windows.Forms.Label();
            this.labelQualityDescription = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelMissingPoster = new System.Windows.Forms.Label();
            this.panelPoster.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(12, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(650, 35);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "labelName";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPoster
            // 
            this.panelPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPoster.Controls.Add(this.labelMissingPoster);
            this.panelPoster.Location = new System.Drawing.Point(17, 74);
            this.panelPoster.Name = "panelPoster";
            this.panelPoster.Size = new System.Drawing.Size(294, 364);
            this.panelPoster.TabIndex = 1;
            // 
            // labelGenreDescription
            // 
            this.labelGenreDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenreDescription.Location = new System.Drawing.Point(338, 74);
            this.labelGenreDescription.Name = "labelGenreDescription";
            this.labelGenreDescription.Size = new System.Drawing.Size(168, 23);
            this.labelGenreDescription.TabIndex = 2;
            this.labelGenreDescription.Text = "Жанр:";
            this.labelGenreDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReleaseDate.Location = new System.Drawing.Point(509, 114);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(153, 23);
            this.labelReleaseDate.TabIndex = 5;
            this.labelReleaseDate.Text = "labelReleaseDate";
            this.labelReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReleaseDateDescription
            // 
            this.labelReleaseDateDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReleaseDateDescription.Location = new System.Drawing.Point(338, 114);
            this.labelReleaseDateDescription.Name = "labelReleaseDateDescription";
            this.labelReleaseDateDescription.Size = new System.Drawing.Size(168, 23);
            this.labelReleaseDateDescription.TabIndex = 4;
            this.labelReleaseDateDescription.Text = "Дата выхода:";
            this.labelReleaseDateDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRuntime
            // 
            this.labelRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRuntime.Location = new System.Drawing.Point(509, 154);
            this.labelRuntime.Name = "labelRuntime";
            this.labelRuntime.Size = new System.Drawing.Size(153, 23);
            this.labelRuntime.TabIndex = 7;
            this.labelRuntime.Text = "labelRuntime";
            this.labelRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRuntimeDescription
            // 
            this.labelRuntimeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRuntimeDescription.Location = new System.Drawing.Point(338, 154);
            this.labelRuntimeDescription.Name = "labelRuntimeDescription";
            this.labelRuntimeDescription.Size = new System.Drawing.Size(168, 23);
            this.labelRuntimeDescription.TabIndex = 6;
            this.labelRuntimeDescription.Text = "Продолжительность:";
            this.labelRuntimeDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompany
            // 
            this.labelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCompany.Location = new System.Drawing.Point(509, 194);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(153, 23);
            this.labelCompany.TabIndex = 9;
            this.labelCompany.Text = "labelCompany";
            this.labelCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyDescription
            // 
            this.labelCompanyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCompanyDescription.Location = new System.Drawing.Point(338, 194);
            this.labelCompanyDescription.Name = "labelCompanyDescription";
            this.labelCompanyDescription.Size = new System.Drawing.Size(168, 23);
            this.labelCompanyDescription.TabIndex = 8;
            this.labelCompanyDescription.Text = "Компания:";
            this.labelCompanyDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFormat
            // 
            this.labelFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFormat.Location = new System.Drawing.Point(509, 234);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(153, 23);
            this.labelFormat.TabIndex = 11;
            this.labelFormat.Text = "labelFormat";
            this.labelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFormatDescription
            // 
            this.labelFormatDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFormatDescription.Location = new System.Drawing.Point(338, 234);
            this.labelFormatDescription.Name = "labelFormatDescription";
            this.labelFormatDescription.Size = new System.Drawing.Size(168, 23);
            this.labelFormatDescription.TabIndex = 10;
            this.labelFormatDescription.Text = "Формат:";
            this.labelFormatDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelQuality
            // 
            this.labelQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuality.Location = new System.Drawing.Point(509, 274);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(153, 23);
            this.labelQuality.TabIndex = 13;
            this.labelQuality.Text = "labelQuality";
            this.labelQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelQualityDescription
            // 
            this.labelQualityDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQualityDescription.Location = new System.Drawing.Point(338, 274);
            this.labelQualityDescription.Name = "labelQualityDescription";
            this.labelQualityDescription.Size = new System.Drawing.Size(168, 23);
            this.labelQualityDescription.TabIndex = 12;
            this.labelQualityDescription.Text = "Качество:";
            this.labelQualityDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGenre
            // 
            this.labelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenre.Location = new System.Drawing.Point(509, 74);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(153, 23);
            this.labelGenre.TabIndex = 3;
            this.labelGenre.Text = "labelGenre";
            this.labelGenre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(379, 393);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(250, 45);
            this.buttonBack.TabIndex = 14;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // labelMissingPoster
            // 
            this.labelMissingPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMissingPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMissingPoster.Location = new System.Drawing.Point(0, 0);
            this.labelMissingPoster.Name = "labelMissingPoster";
            this.labelMissingPoster.Size = new System.Drawing.Size(292, 362);
            this.labelMissingPoster.TabIndex = 0;
            this.labelMissingPoster.Text = "Изображение отсутствует";
            this.labelMissingPoster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMissingPoster.Visible = false;
            // 
            // MovieDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 465);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelQuality);
            this.Controls.Add(this.labelQualityDescription);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.labelFormatDescription);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelCompanyDescription);
            this.Controls.Add(this.labelRuntime);
            this.Controls.Add(this.labelRuntimeDescription);
            this.Controls.Add(this.labelReleaseDate);
            this.Controls.Add(this.labelReleaseDateDescription);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelGenreDescription);
            this.Controls.Add(this.panelPoster);
            this.Controls.Add(this.labelName);
            this.Name = "MovieDetailsForm";
            this.Text = "Детали";
            this.panelPoster.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelPoster;
        private System.Windows.Forms.Label labelGenreDescription;
        private System.Windows.Forms.Label labelReleaseDate;
        private System.Windows.Forms.Label labelReleaseDateDescription;
        private System.Windows.Forms.Label labelRuntime;
        private System.Windows.Forms.Label labelRuntimeDescription;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelCompanyDescription;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label labelFormatDescription;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.Label labelQualityDescription;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelMissingPoster;
    }
}