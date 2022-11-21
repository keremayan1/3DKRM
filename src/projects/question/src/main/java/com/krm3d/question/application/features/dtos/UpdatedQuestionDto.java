package com.krm3d.question.application.features.dtos;

import lombok.Data;
import org.springframework.data.annotation.Id;

@Data
public class UpdatedQuestionDto {
    @Id
    private String id;
    private String questionTitleId;
    private String questionName;
}
