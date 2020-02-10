import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalComponent } from '../common/modal/modal.component';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ProjectService, CreateProjectRequest } from '../common/base-http-service.service';

@Component({
	selector: 'app-add-project-modal',
	templateUrl: './add-project-modal.component.html',
	styleUrls: [ './add-project-modal.component.scss' ]
})
export class AddProjectModalComponent implements OnInit {
	@ViewChild(ModalComponent, { static: true })
	dialog: ModalComponent;

	newProjectForm: FormGroup;

	constructor(fb: FormBuilder, private projectService: ProjectService) {
		this.newProjectForm = fb.group({
			name: [ '', Validators.required ],
			alias: [ '', Validators.required ],
			description: [ '' ]
		});
	}

	ngOnInit() {}

	open() {
		this.dialog.open();
	}

	close() {
		this.dialog.close();
	}
	submitForm() {
		let body: CreateProjectRequest = {
			name: this.newProjectForm.value.name,
			alias: this.newProjectForm.value.alias,
			description: this.newProjectForm.value.description
		};
		this.projectService.create(body).subscribe((test) => console.log('tag', ''));
		this.close();
	}
}
