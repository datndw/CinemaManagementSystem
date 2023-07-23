using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Persistence.Extensions
{
    public static class DataExtension
    {
        public static List<Company> Companies = new List<Company>
        {
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Lucasfilm Ltd.",
                Description = "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.",
                ImageUrl = "/o86DbpburjxrqAzEDhXZcyE8pDb.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Columbia Pictures",
                Description = "Columbia Pictures Industries, Inc. (CPII) is an American film production and distribution company. Columbia Pictures now forms part of the Columbia TriStar Motion Picture Group, owned by Sony Pictures Entertainment, a subsidiary of the Japanese conglomerate Sony. It is one of the leading film companies in the world, a member of the so-called Big Six. It was one of the so-called Little Three among the eight major film studios of Hollywood's Golden Age.",
                ImageUrl = "/71BqEFAF4V3qjjMPCpLuyJFB9A.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "DreamWorks Pictures",
                Description = "Nhắc đến DreamWorks Pictures không thể không nghĩ tới hình ảnh cậu bé ngồi câu sao trên mặt trăng tượng trưng cho không biết, chắc là flex kiểu điện ảnh chuyên nghiệp =))",
                ImageUrl = "/vru2SssLX3FPhnKZGtYw00pVIS9.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "New Line Cinema",
                Description = "Kiểu như đường kẻ mới =)) Chứ còn gì nữa",
                ImageUrl = "/78ilmDNTpdCfsakrsLqmAUkFTrO.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Walt Disney Pictures",
                Description = "Cái này có phải Disney không nhỉ?",
                ImageUrl = "/wdrCwmRnLFJhEoH8GSfymY85KHT.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Pixar",
                Description = "Cái công ty mà có cái đèn nhảy nhảy đè chứ I đúng không =))",
                ImageUrl = "/1TjvGVDMYsj6JBxOAkUHpPEwLf7.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = new Guid(1,1,1,1,1,1,1,1,1,1,1),
                Firstname = "System",
                Lastname = "Administrator",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new User
            {
                Id = new Guid(2,2,2,2,2,2,2,2,2,2,2),
                Firstname = "System",
                Lastname = "Publisher",
                CompanyId = Companies.ElementAt(0).Id,
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new User
            {
                Id = new Guid(3,3,3,3,3,3,3,3,3,3,3),
                Firstname = "System",
                Lastname = "User",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
        };

        public static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Fast & Furious X",
                Description = "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.",
                ImageUrl = "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg",
                BackDropUrl = "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg",
                TrailerUrl = "/eoOaKN4qCKw",
                AgeRequired = 8,
                ReleaseDate = new DateTime(2023,5,17),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Knights of the Zodiac",
                Description = "Khi nữ thần chiến tranh Athena tái sinh trong cơ thể của một cô gái trẻ tên Sienna, chàng trai mồ côi Seiya phát hiện số phận của anh được định sẵn để bảo vệ cô và giải cứu thế giới. Nếu muốn sống sót, Seiya cần phải nắm lấy vận mệnh của mình và hy sinh mọi thứ để có được vị trí xứng đáng trong số các Hiệp sĩ Hoàng đạo.",
                ImageUrl = "/7Hb59xDBe9fUPcR3VYFnLMCioLL.jpg",
                BackDropUrl = "/oqP1qEZccq5AD9TVTIaO6IGUj7o.jpg",
                TrailerUrl = "/Sko0o_KoBHY",
                AgeRequired = 12,
                ReleaseDate = new DateTime(2023, 4, 27),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Vệ Binh Dải Ngân Hà 3",
                Description = "Cho dù vũ trụ này có bao la đến đâu, các Vệ Binh của chúng ta cũng không thể trốn chạy mãi mãi.",
                ImageUrl = "/Ak5hAxorxMpxKoVw5e3kGfxs7sY.jpg",
                BackDropUrl = "/5YZbUmjbMa3ClvSW1Wj3D6XGolb.jpg",
                TrailerUrl = "/JqcncLPi9zw",
                AgeRequired = 12,
                ReleaseDate = new DateTime(2023, 5, 3),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Khi Nhà Vợ Làm Tội Phạm",
                Description = "Khi ngân hàng mà Owen quản lý bị cướp chỉ vài ngày trước đám cưới của anh, mọi chứng cứ đều chỉ về một hướng cực kỳ khó xử: bố mẹ vợ tương lai của anh.",
                ImageUrl = "/5dliMQ2ODbGNoq0hlefdnuXQxMw.jpg",
                BackDropUrl = "/fjWcAbHRxCSR4kLGvsPEhNjR2ts.jpg",
                TrailerUrl = "/MvPaDziB-ac",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 7, 7),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Nhiệm Vụ: Bất Khả Thi - Nghiệp Báo Phần 1",
                Description = "Phần phim thứ 7 của loạt phim Nhiệm Vụ Bất Khả Thi",
                ImageUrl = "/eoLBADTttXo4HJLLUK9amxE4RRM.jpg",
                BackDropUrl = "/628Dep6AxEtDxjZoGP78TsOxYbK.jpg",
                TrailerUrl = "/o0We5hcYM7o",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 7, 8),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Quỷ Quyệt: Cửa Đỏ Vô Định",
                Description = "To put their demons to rest once and for all, Josh Lambert and a college-aged Dalton Lambert must go deeper into The Further than ever before, facing their family's dark past and a host of new and more horrifying terrors that lurk behind the red door.",
                ImageUrl = "/faafq0NouR3wSemwc77slLEJHId.jpg",
                BackDropUrl = "/aO6hDsqTIAtQFUBoPWklmPFsSTW.jpg",
                TrailerUrl = "/aGBOK2cnHSE",
                AgeRequired = 16,
                ReleaseDate = new DateTime(2023, 7, 5),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Indiana Jones và Vòng Quay Định Mệnh",
                Description = "Indiana Jones 5 sẽ pha trộn giữa thực tế, hư cấu khi lấy bối cảnh năm 1969, lần này Indiana Jones sẽ đối mặt với Đức quốc xã trong thời gian diễn ra cuộc chạy đua vào không gian.",
                ImageUrl = "/gTAR51U4eAiCokNqtRy7FsprUar.jpg",
                BackDropUrl = "/35z8hWuzfFUZQaYog8E9LsXW3iI.jpg",
                TrailerUrl = "/6u93f9fQ8yY",
                AgeRequired = 16,
                ReleaseDate = new DateTime(2022, 6, 28),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Anh Em Super Mario",
                Description = "The Super Mario Bros. Movie xoay quanh cuộc phiêu lưu ở thế giới Vương quốc Nấm của anh em thợ sửa ống nước Mario và Luigi. Sau khi tình cờ bước tới vùng đất lạ từ một ống nước, Luigi đã bị chia tách với Mario và rơi vào tay quái vật rùa xấu xa Bowser, hắn đang âm mưu độc chiếm thế giới. Trong lúc cố gắng tìm kiếm người anh em của mình, Mario đã chạm mặt anh bạn nấm Toad và công chúa Peach. Từ đây họ sát cánh bên nhau trên hành trình ngăn chặn thế lực hắc ám.",
                ImageUrl = "/gRlfFcpPdjREQ3lgeuAuB10gfbR.jpg",
                BackDropUrl = "/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg",
                TrailerUrl = "/QcinmCfoh8E",
                AgeRequired = 8,
                ReleaseDate = new DateTime(2021, 6, 11),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Blackening",
                Description = "A group of Black friends reunite for a Juneteenth weekend getaway only to find themselves trapped in a remote cabin with a twisted killer.",
                ImageUrl = "/n2aS9FE0C3VUHtSb3Ak41aU9K3y.jpg",
                BackDropUrl = "/wuwMLVIY0Zqfz6uToyDmb7TYRVN.jpg",
                TrailerUrl = "/moiRCJR4ToY",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2022, 1, 11),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Mùi Hương Của Vàng",
                Description = "Quyết tâm tìm kiếm công bằng cũng như lợi nhuận từ công việc bạc bẽo, một công nhân nhà máy âm mưu tuồn nước hoa xa xỉ qua mặt sếp mình.",
                ImageUrl = "/4x9u5HsxeSJu9SW9Pf6fVVDPwxv.jpg",
                BackDropUrl = "/k1gMjXi1vtwTDiGwfBw7L897zs3.jpg",
                TrailerUrl = "/2lwzVZkuGKE",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2022, 12, 11),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Người Nhện: Du Hành Vũ Trụ Nhện",
                Description = "Miles Morales tái xuất trong phần tiếp theo của bom tấn hoạt hình từng đoạt giải Oscar - Spider-Man: Across the Spider-Verse. Sau khi gặp lại Gwen Stacy, chàng Spider-Man thân thiện đến từ Brooklyn phải du hành qua đa vũ trụ và gặp một nhóm Người Nhện chịu trách nhiệm bảo vệ các thế giới song song. Nhưng khi nhóm siêu anh hùng xung đột về cách xử lý một mối đe dọa mới, Miles buộc phải đọ sức với các Người Nhện khác và phải xác định lại ý nghĩa của việc trở thành một người hùng để có thể cứu những người cậu yêu thương nhất.",
                ImageUrl = "/bX547n5W9ZIKCeAE44Vf2nfw4w.jpg",
                BackDropUrl = "/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg",
                TrailerUrl = "/sKYjLmtWbug",
                AgeRequired = 12,
                ReleaseDate = new DateTime(2021, 11, 4),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "A Place to Fight For",
                Description = "Greg is a police lieutenant; he must collect informations on eco-activists, infiltrating them for months. Myriam, a young free woman, is fighting to save a forest from the building of a dam. They meet and fall in love on the Zone. A beautiful life, a joy that Greg discovers, despite the risks of being unmasked. For each of them, time is short: soon everything will disappear.",
                ImageUrl = "/36wyM5ceCCIpu8lU88mxonYET71.jpg",
                BackDropUrl = "/3LzSMuatf6E6xw6i9F8LnvBZmAy.jpg",
                TrailerUrl = "/g1mHBd5dM6Y",
                AgeRequired = 12,
                ReleaseDate = new DateTime(2022, 6, 4),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Avatar:  Dòng Chảy Của Nước",
                Description = "Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.",
                ImageUrl = "/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg",
                BackDropUrl = "/8rpDcsfLJypbO6vREc0547VKqEv.jpg",
                TrailerUrl = "/gq2xKJXYZ80",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 6, 1),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Vây Hãm: Không Lối Thoát",
                Description = "Quái vật cơ bắp Seok-do (Ma Dong Seok) dẫn đầu đội hình sự truy lùng đường dây buôn chất cấm của thiếu gia Joo Seong Cheol. Cuộc truy đuổi càng thêm gay cấn khi cú đấm công lý \"chú Ma\" chạm trán thanh kiếm lừng lẫy chốn giang hồ Nhật Bản.",
                ImageUrl = "/jeRp9uQSt4IkpGPqR2iWviRUEsE.jpg",
                BackDropUrl = "/vblTCXOWUQGSc837vgbhDRi4HSc.jpg",
                TrailerUrl = "/Efe7oVx27E4",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 1, 1),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Khóa Chặt Cửa Nào Suzume",
                Description = "Câu chuyện bắt đầu khi Suzume vô tình gặp chàng trai Souta đến thị trấn nơi cô sinh sống với mục đích tìm kiếm \"một cánh cửa\". Để bảo vệ Nhật Bản khỏi thảm họa, những cánh cửa rải rác khắp nơi phải được đóng lại, và bất ngờ thay Suzume cũng có khả năng đóng cửa đặc biệt này. Từ đó cả hai cùng nhau thực hiện sự mệnh \"khóa chặt cửa\"!",
                ImageUrl = "/70f6AyM2U74up5MaPAZJ7AAnKKL.jpg",
                BackDropUrl = "/4tdV5AeojEdbvn6VpeQrbuDlmzs.jpg",
                TrailerUrl = "/xQ4_c8JfuzI",
                AgeRequired = 16,
                ReleaseDate = new DateTime(2020, 9, 1),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Barbie",
                Description = "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.",
                ImageUrl = "/mqNkQhaXxsH8SLNmJnG5oGz4meR.jpg",
                BackDropUrl = "/nHf61UzkfFno5X1ofIhugCPus2R.jpg",
                TrailerUrl = "/pBk4NYhWNMM",
                AgeRequired = 8,
                ReleaseDate = new DateTime(2021, 6, 1),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Nimona",
                Description = "Bị đổ oan tội ác bi thảm, hiệp sĩ nọ bắt tay với một thiếu nữ kiên cường, có khả năng thay đổi hình dạng để minh oan. Nhưng sẽ ra sao nếu cô là con quái vật anh thề sẽ tiêu diệt?",
                ImageUrl = "/2NQljeavtfl22207D1kxLpa4LS3.jpg",
                BackDropUrl = "/4QpKxH614YFIsmiIBVUbsnG2H8w.jpg",
                TrailerUrl = "/f_fuHRyQbOc",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2022, 1, 7),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Sát Thủ John Wick: Phần 4",
                Description = "Sát Thủ John Wick: Chương 4 là câu chuyện của John Wick (Keanu Reeves) đã khám phá ra con đường để đánh bại High Table. Nhưng trước khi có thể kiếm được tự do, Wick phải đối đầu với kẻ thù mới với những liên minh hùng mạnh trên toàn cầu và những lực lượng biến những người bạn cũ thành kẻ thù.",
                ImageUrl = "/ksg3XSEezxpRVEB6BrKxmNOuhft.jpg",
                BackDropUrl = "/7I6VUdPj6tQECNHdviJkUHD2u89.jpg",
                TrailerUrl = "/qEVUtrk8_B4",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 1, 4),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Xứ Sở Các Nguyên Tố",
                Description = "Xứ Sở Các Nguyên Tố từ Disney và Pixar lấy bối cảnh tại thành phố các các nguyên tố, nơi lửa, nước, đất và không khí cùng chung sống với nhau. Câu chuyện xoay quanh nhân vật Ember, một cô nàng cá tính, thông minh, mạnh mẽ và đầy sức hút. Tuy nhiên, mối quan hệ của cô với Wade - một anh chàng hài hước, luôn thuận thế đẩy dòng - khiến Ember cảm thấy ngờ vực với thế giới này.",
                ImageUrl = "/7GaeF6xeUbfXFZCtOCWs503CJUl.jpg",
                BackDropUrl = "/cSYLX73WskxCgvpN3MtRkYUSj1T.jpg",
                TrailerUrl = "/maq_YK88Xnw",
                AgeRequired = 10,
                ReleaseDate = new DateTime(2022, 3, 24),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Sound of Freedom",
                Description = "The story of Tim Ballard, a former US government agent, who quits his job in order to devote his life to rescuing children from global sex traffickers.",
                ImageUrl = "/mx4O9OEvIB265VM3UATLslsSW5t.jpg",
                BackDropUrl = "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg",
                TrailerUrl = "/Rt0kp4VW1cI",
                AgeRequired = 12,
                ReleaseDate = new DateTime(2023, 3, 24),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Initiated",
                Description = "Based on the novels by Colombian writer Mario Mendoza and on the character of detective Frank Molina, the filming of Los Initiados took place in Bogotá. In the saga of Frank Molina, which uses the books Lady Massacre, La melancolia de los feos, El diario del fin del mundo and Akelarre, the story of an alcoholic private investigator who unmasks sinister plots within the underworld of Bogotá is told.",
                ImageUrl = "/3FzWr7u7uFaLpolFQlUbibFDpQJ.jpg",
                BackDropUrl = "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg",
                TrailerUrl = "/mJ8DsRHZRH8",
                AgeRequired = 14,
                ReleaseDate = new DateTime(2023, 3, 21),
                Status = "Active",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }
        };

        public static List<Genre> Genres = new List<Genre>
        {
            new Genre //28
            {
                Id = Guid.NewGuid(),
                Name = "Phim Hành Động",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //12
            {
                Id = Guid.NewGuid(),
                Name = "Phim Phiêu Lưu",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //16
            {
                Id = Guid.NewGuid(),
                Name = "Phim Hoạt Hình",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //35
            {
                Id = Guid.NewGuid(),
                Name = "Phim Hài",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //80
            {
                Id = Guid.NewGuid(),
                Name = "Phim Hình Sự",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //99
            {
                Id = Guid.NewGuid(),
                Name = "Phim Tài Liệu",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //18
            {
                Id = Guid.NewGuid(),
                Name = "Phim Chính Kịch",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //10751
            {
                Id = Guid.NewGuid(),
                Name = "Phim Gia Đình",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //14
            {
                Id = Guid.NewGuid(),
                Name = "Phim Giả Tượng",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //36
            {
                Id = Guid.NewGuid(),
                Name = "Phim Lịch Sử",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //27
            {
                Id = Guid.NewGuid(),
                Name = "Phim Kinh Dị",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //10402
            {
                Id = Guid.NewGuid(),
                Name = "Phim Nhạc",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //9648
            {
                Id = Guid.NewGuid(),
                Name = "Phim Bí Ẩn",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //10749
            {
                Id = Guid.NewGuid(),
                Name = "Phim Lãng Mạn",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //878
            {
                Id = Guid.NewGuid(),
                Name = "Phim Khoa Học Viễn Tưởng",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //10770
            {
                Id = Guid.NewGuid(),
                Name = "Chương Trình Truyền Hình",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //53
            {
                Id = Guid.NewGuid(),
                Name = "Phim Gây Cấn",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //10752
            {
                Id = Guid.NewGuid(),
                Name = "Phim Chiến Tranh",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Genre //37
            {
                Id = Guid.NewGuid(),
                Name = "Phim Miền Tây",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }
        };

        public static List<Actor> Actors = new List<Actor>
        {
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "Kane Karrtima",
                Description = "Nam diễn viên chuyên nghiệp góp mặt trong nhiều bộ phim đình đám của các hãng phim Châu Âu",
                BirthDate = new DateTime(1982, 11, 3),
                Gender = "Male",
                ImageUrl = "/mDLDvsx8PaZoEThkBdyaG1JxPdf.jpg",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "John Makanno",
                Description = "Ông được cho là diễn viên điện ảnh tâm huyết nhất khi tính tới năm 2023, ông đã thro đuổi đam mê được 38 năm",
                BirthDate = new DateTime(1959, 12, 6),
                Gender = "Male",
                ImageUrl = "/2ZulC2Ccq1yv3pemusks6Zlfy2s.jpg",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "David Reynolds",
                Description = "Dave began his writing career in 1993 as one of the original writers on NBC's \"Late Night With Conan O'Brien.\" After more than 400 shows, Dave moved to Los Angeles in 1995 and landed a job at Walt Disney Feature Animation in the movie \"Tarzan.\"",
                BirthDate = new DateTime(1966, 1, 4),
                Gender = "Male",
                ImageUrl = "/5iKtATPbLpv2lT7q9DPX2v2qPS1.jpg",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "Alexander Gould",
                Description = "Chàng diễn viên trẻ tuổi với những thành tựu lớn lao trong sự nghiệp mới chớm nở của anh tại WestKark",
                BirthDate = new DateTime(1990, 4, 2),
                Gender = "Male",
                ImageUrl = "/fe4mUSp0XotA6Ku4Bs69Q9o2lqU.jpg",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "Ellen DeGeneres",
                Description = "Diễn viên không thể thiếu trong các tựa phim hành động, phiêu lưu có tính chất liều lĩnh, ngoan cường",
                BirthDate = new DateTime(1987, 8, 1),
                Gender = "Male",
                ImageUrl = "/z8IEEid4z63CBlJtxrTKEfsW7NA.jpg",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
        };

        public static List<Rate> Rates = new List<Rate>
        {

            new Rate
            {
                Id = Guid.NewGuid(),
                Rating = 9.5,
                Comment = "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi",
                MovieId = Movies.ElementAt(0).Id,
                UserId = Users.ElementAt(0).Id,
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }

        };

        public static List<MovieActor> MovieActors = new List<MovieActor>
        {
            new MovieActor
            {
                MovieId = Movies.ElementAt(0).Id,
                ActorId = Actors.ElementAt(0).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(0).Id,
                ActorId = Actors.ElementAt(1).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(1).Id,
                ActorId = Actors.ElementAt(0).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(2).Id,
                ActorId = Actors.ElementAt(0).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(2).Id,
                ActorId = Actors.ElementAt(1).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(3).Id,
                ActorId = Actors.ElementAt(0).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(5).Id,
                ActorId = Actors.ElementAt(3).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(2).Id,
                ActorId = Actors.ElementAt(4).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(3).Id,
                ActorId = Actors.ElementAt(4).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(4).Id,
                ActorId = Actors.ElementAt(2).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(5).Id,
                ActorId = Actors.ElementAt(2).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(7).Id,
                ActorId = Actors.ElementAt(3).Id,
            },
            new MovieActor
            {
                MovieId = Movies.ElementAt(18).Id,
                ActorId = Actors.ElementAt(2).Id,
            },
        };

        public static List<MovieCompany> MovieCompanies = new List<MovieCompany>
        {
            new MovieCompany
            {
                MovieId = Movies.ElementAt(0).Id,
                CompanyId = Companies.ElementAt(0).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(3).Id,
                CompanyId = Companies.ElementAt(0).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(2).Id,
                CompanyId = Companies.ElementAt(0).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(5).Id,
                CompanyId = Companies.ElementAt(1).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(7).Id,
                CompanyId = Companies.ElementAt(1).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(8).Id,
                CompanyId = Companies.ElementAt(2).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(10).Id,
                CompanyId = Companies.ElementAt(2).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(9).Id,
                CompanyId = Companies.ElementAt(3).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(14).Id,
                CompanyId = Companies.ElementAt(3).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(19).Id,
                CompanyId = Companies.ElementAt(4).Id,
            },
            new MovieCompany
            {
                MovieId = Movies.ElementAt(11).Id,
                CompanyId = Companies.ElementAt(5).Id,
            },
        };

        public static List<MovieGenre> MovieGenres = new List<MovieGenre>
        {
            new MovieGenre
            {
                MovieId = Movies.ElementAt(0).Id,
                GenreId = Genres.ElementAt(0).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(0).Id,
                GenreId = Genres.ElementAt(13).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(1).Id,
                GenreId = Genres.ElementAt(11).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(1).Id,
                GenreId = Genres.ElementAt(0).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(2).Id,
                GenreId = Genres.ElementAt(1).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(2).Id,
                GenreId = Genres.ElementAt(0).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(3).Id,
                GenreId = Genres.ElementAt(3).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(4).Id,
                GenreId = Genres.ElementAt(2).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(5).Id,
                GenreId = Genres.ElementAt(11).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(5).Id,
                GenreId = Genres.ElementAt(10).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(6).Id,
                GenreId = Genres.ElementAt(8).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(7).Id,
                GenreId = Genres.ElementAt(8).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(8).Id,
                GenreId = Genres.ElementAt(7).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(9).Id,
                GenreId = Genres.ElementAt(5).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(9).Id,
                GenreId = Genres.ElementAt(2).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(10).Id,
                GenreId = Genres.ElementAt(4).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(11).Id,
                GenreId = Genres.ElementAt(3).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(12).Id,
                GenreId = Genres.ElementAt(1).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(13).Id,
                GenreId = Genres.ElementAt(1).Id,
            },
            new MovieGenre
            {
                MovieId = Movies.ElementAt(13).Id,
                GenreId = Genres.ElementAt(0).Id,
            }
        };

        public static List<MovieUser> MovieUsers = new List<MovieUser>
        {
            new MovieUser
            {
                MovieId = Movies.ElementAt(0).Id,
                UserId = Users.ElementAt(2).Id,
            },
            new MovieUser
            {
                MovieId = Movies.ElementAt(2).Id,
                UserId = Users.ElementAt(2).Id,
            },
            new MovieUser
            {
                MovieId = Movies.ElementAt(4).Id,
                UserId = Users.ElementAt(2).Id,
            },
            new MovieUser
            {
                MovieId = Movies.ElementAt(6).Id,
                UserId = Users.ElementAt(2).Id,
            },
            new MovieUser
            {
                MovieId = Movies.ElementAt(8).Id,
                UserId = Users.ElementAt(2).Id,
            },
            new MovieUser
            {
                MovieId = Movies.ElementAt(10).Id,
                UserId = Users.ElementAt(2).Id,
            }
        };
    }
}