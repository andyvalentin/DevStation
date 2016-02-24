namespace DevStation.Controllers {
    export class EmployerProfileController {
        public employer;
        

        public toEmployerEdit() {
            this.$uibModal.open({
                templateUrl: 'Presentation/ngApp/views/employerProfileEdit.html',
                controller: DevStation.Controllers.EmployerProfileController,
                controllerAs: 'c'
            });
        }

        public editEmployerProfile() {
            this.$http.post(`api/user/employerprofile/edit`, this.employer)
                .then((response) => {
                    this.$location.path("/employer/profile")
                })
        }

        public toAddJob() {
            this.$location.path("/employer/addjob")
        }

        public completeJob(id:number) {
            this.$http.get(`api/jobs/completejob/${id}`)
                .then((response) => {
                    this.$http.get(`api/users/employerProfile`)
                        .then((response) => {
                            this.employer = response.data;
                        })
                })
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService, private $window, private $uibModal) {
            this.$http.get(`/api/users/employerProfile`)
                .then((response) => {
                    this.employer = response.data;
                })
        }
    }
}