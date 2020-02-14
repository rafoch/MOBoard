import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIssueModalComponent } from './add-issue-modal.component';

describe('AddIssueModalComponent', () => {
  let component: AddIssueModalComponent;
  let fixture: ComponentFixture<AddIssueModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddIssueModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddIssueModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
